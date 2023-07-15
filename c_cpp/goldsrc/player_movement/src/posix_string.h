#ifndef POSIX_STRING_H
#define POSIX_STRING_H

#ifdef _WIN32
#include <string.h>
#define STRICMP _stricmp
#define STRNICMP _strnicmp
#else
#include "safe_str_lib.h"
#define STRICMP strcasecmp
#define STRNICMP strncasecmp
#endif

#endif // POSIX_STRING_H
