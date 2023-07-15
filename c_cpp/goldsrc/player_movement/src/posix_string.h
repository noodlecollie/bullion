#ifndef POSIX_STRING_H
#define POSIX_STRING_H

#ifdef _WIN32
#define STRICMP _stricmp
#define STRNICMP _strnicmp
#else
#define STRICMP stricmp
#define STRNICMP strnicmp
#endif

#endif // POSIX_STRING_H
